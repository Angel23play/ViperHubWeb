import { useState, useEffect } from "react";
import axios from "axios";

function PostList({ setHandle, setPostId, setShowPostInput }) {
    const [posts, setPosts] = useState([]);
    const [comments, setComments] = useState([]);
    const [showCommentModal, setShowCommentModal] = useState(false);
    const [showDeleteModal, setShowDeleteModal] = useState(false);
    const [selectedPostId, setSelectedPostId] = useState(null);
    const [parentCommentId, setParentCommentId] = useState(null);
    const [commentText, setCommentText] = useState("");
    const [deleteType, setDeleteType] = useState(""); // Nuevo estado para distinguir entre post y comentario
    let url = `${import.meta.env.VITE_API_URL}`;

    const handleImageUrls = (text) => {
        const regex = /(https?:\/\/.*\.(?:png|jpg|jpeg|gif|bmp|svg))/g;
        const escapedText = text.replace(/</g, "&lt;").replace(/>/g, "&gt;");

        const formattedText = escapedText.replace(
            regex,
            (match) =>
                `<div class="my-2"><img src="${match}" alt="Imagen" class="img-fluid rounded" style="max-height: 400px;" /></div>`
        );

        return formattedText.replace(/\n/g, "<br>");
    };

    useEffect(() => {
        async function GetAllPosts() {
            try {
                const response = await axios.get(`${url}Themes`);
                if (Array.isArray(response.data)) {
                    setPosts(response.data);
                }
            } catch (error) {
                console.error("Error al obtener posts:", error);
            }
        }

        async function GetAllComments() {
            try {
                const response = await axios.get(`${url}Comments`);
                if (Array.isArray(response.data)) {
                    setComments(response.data);
                }
            } catch (error) {
                console.error("Error al obtener comentarios:", error);
            }
        }

        GetAllPosts();
        GetAllComments();
    }, [url]);

    const handleEdit = (id) => {
        setHandle(1);
        setPostId(id);
        setShowPostInput(true);
    };

    const handleDelete = async () => {
        try {
            if (deleteType === "post") {
                await axios.delete(`${url}Themes/${selectedPostId}`);
                setPosts(posts.filter((post) => post.id !== selectedPostId));
            } else if (deleteType === "comment") {
                await axios.delete(`${url}Comments/${selectedPostId}`);
                setComments(comments.filter((comment) => comment.id !== selectedPostId));
            }
            setShowDeleteModal(false);
        } catch (error) {
            console.error("Error al eliminar", error);
        }
    };

    const handleShowDeleteModal = (id, type) => {
        setSelectedPostId(id);
        setDeleteType(type);
        setShowDeleteModal(true);
    };

    const handleCloseDeleteModal = () => {
        setShowDeleteModal(false);
        setSelectedPostId(null);
        setDeleteType("");
    };

    const handleShowCommentModal = (postId, parentId = null) => {
        setSelectedPostId(postId);
        setParentCommentId(parentId);
        setShowCommentModal(true);
    };

    const handleCloseCommentModal = () => {
        setShowCommentModal(false);
        setSelectedPostId(null);
        setParentCommentId(null);
        setCommentText("");
    };

    const handleCommentSubmit = async () => {
        if (!commentText) return;

        try {
            const newComment = {
                content: commentText,
                dateCreation: new Date().toISOString(),
                usuarioId: 1,
                temaForoId: selectedPostId,
                comentarioPadreId: parentCommentId ?? null,
            };
            await axios.post(`${url}Comments`, newComment);
            handleCloseCommentModal();

            const updated = await axios.get(`${url}Comments`);
            setComments(updated.data);
        } catch (error) {
            console.error("Error al enviar comentario", error);
            handleCloseCommentModal();
            const updated = await axios.get(`${url}Comments`);
            setComments(updated.data);
        }
    };

    const renderComments = (postId, parentId = null) => {
        const filtered = comments.filter(
            (c) => c.temaForoId === postId && c.comentarioPadreId === parentId
        );

        return filtered.map((comment) => (
            <div key={comment.id} className="ms-4 border-start ps-3 mt-2">
                <p dangerouslySetInnerHTML={{ __html: handleImageUrls(comment.content) }} />
                <div className="d-flex flex-wrap gap-2 justify-content-between">
                    <button
                        className="btn btn-sm btn-outline-primary"
                        onClick={() => handleShowCommentModal(postId, comment.id)}
                    >
                        Responder
                    </button>
                    <button
                        className="btn btn-sm btn-danger"
                        onClick={() => handleShowDeleteModal(comment.id, "comment")}
                    >
                        Eliminar
                    </button>
                </div>
                {renderComments(postId, comment.id)}
            </div>
        ));
    };

    return (
        <div className="container">
            {posts.length === 0 ? (
                <h2 className="text-center text-muted mb-4">No hay publicaciones aún.</h2>
            ) : (
                posts.map((post) => (
                    <div key={post.id} className="card shadow-sm mb-4">
                        <div className="card-body">
                            <div className="d-flex flex-column flex-md-row justify-content-between align-items-start">
                                <div className="flex-grow-1 me-md-3">
                                    <h5 className="card-title text-primary">{post.title}</h5>
                                    <p dangerouslySetInnerHTML={{ __html: handleImageUrls(post.content) }} />
                                </div>
                                <div className="d-flex flex-wrap gap-2 justify-content-end mt-3 mt-md-0">
                                    <button className="btn btn-warning" onClick={() => handleEdit(post.id)}>
                                        <img src="/pencil-svgrepo-com.svg" alt="Editar" width="30" height="30" />
                                    </button>
                                    <button
                                        className="btn btn-danger"
                                        onClick={() => handleShowDeleteModal(post.id, "post")}
                                    >
                                        <img src="/trash-svgrepo-com.svg" alt="Eliminar" width="30" height="30" />
                                    </button>
                                    <button
                                        className="btn btn-info text-white"
                                        onClick={() => handleShowCommentModal(post.id)}
                                    >
                                        Comentar
                                    </button>
                                </div>
                            </div>
                            <div className="mt-3">{renderComments(post.id)}</div>
                        </div>
                    </div>
                ))
            )}

            {showCommentModal && (
                <div className="modal show d-block" tabIndex="-1" role="dialog">
                    <div className="modal-dialog modal-dialog-centered" role="document">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">
                                    {parentCommentId ? "Responder comentario" : "Escribir Comentario"}
                                </h5>
                                <button type="button" className="btn-close" onClick={handleCloseCommentModal}></button>
                            </div>
                            <div className="modal-body">
                                <textarea
                                    className="form-control"
                                    rows="3"
                                    value={commentText}
                                    onChange={(e) => setCommentText(e.target.value)}
                                    placeholder="Escribe tu comentario aquí"
                                />
                            </div>
                            <div className="modal-footer">
                                <button className="btn btn-secondary" onClick={handleCloseCommentModal}>
                                    Cerrar
                                </button>
                                <button className="btn btn-primary" onClick={handleCommentSubmit}>
                                    Enviar
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            )}

            {showDeleteModal && (
                <div className="modal show d-block" tabIndex="-1" role="dialog">
                    <div className="modal-dialog modal-dialog-centered" role="document">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">
                                    {deleteType === "post" ? "Eliminar publicación" : "Eliminar comentario"}
                                </h5>
                                <button
                                    type="button"
                                    className="btn-close"
                                    onClick={handleCloseDeleteModal}
                                ></button>
                            </div>
                            <div className="modal-body">
                                <p>
                                    ¿Estás seguro de que deseas eliminar este {deleteType === "post" ? "post" : "comentario"}?
                                </p>
                            </div>
                            <div className="modal-footer">
                                <button className="btn btn-secondary" onClick={handleCloseDeleteModal}>
                                    Cerrar
                                </button>
                                <button className="btn btn-danger" onClick={handleDelete}>
                                    Eliminar
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            )}
        </div>
    );
}

export default PostList;
