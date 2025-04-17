import axios from "axios";
import React, { useState, useEffect } from "react";

function PostList({ setHandle, setPostId, setShowPostInput }) {
  const [posts, setPosts] = useState([]);
  let url = `${import.meta.env.VITE_API_URL}`;

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
    GetAllPosts();
  }, [url]);

  const handleEdit = (id) => {
    setHandle(1);
    setPostId(id);
    setShowPostInput(true);
  };
  const handleDelete = async (postId) => {
    const confirmDelete = window.confirm(
      "¿Estás seguro de que deseas eliminar este post?"
    );
    if (!confirmDelete) return;

    try {
      await axios.delete(`${url}Themes/${postId}`);
      setPosts(posts.filter((post) => post.id !== postId));
      console.log("Post eliminado exitosamente.");
    } catch (error) {
      console.error("Error al eliminar el post:", error);
    }
  };
  return (
    <div className="container">
      {posts.length === 0 ? (
        <h2 className="text-center text-muted mb-4">
          No hay publicaciones aún.
        </h2>
      ) : (
        posts.map((post) => (
          <div key={post.id} className="card shadow-sm mb-4">
            <div className="card-body d-flex justify-content-between align-items-center">
              <div>
                <h5 className="card-title text-primary">{post.title}</h5>
                <p className="card-text">{post.content}</p>
              </div>
              <div>
                <button
                  className="btn btn-warning me-2"
                  onClick={() => handleEdit(post.id)}
                >
                  <img
                    src="/pencil-svgrepo-com.svg"
                    alt="Editar"
                    width="30"
                    height="30"
                  />
                </button>
                <button
                  className="btn btn-danger"
                  onClick={() => handleDelete(post.id)}
                >
                  <img
                    src="/trash-svgrepo-com.svg"
                    alt="Eliminar"
                    width="30"
                    height="30"
                  />
                </button>
              </div>
            </div>
          </div>
        ))
      )}
    </div>
  );
}

export default PostList;
