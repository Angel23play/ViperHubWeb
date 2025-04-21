import { useState, useEffect } from "react";
import axios from "axios";

function Clans() {
    const url = import.meta.env.VITE_API_URL;
    const [clans, setClans] = useState([]);
    const [leaders, setLeaders] = useState({});
    const [showModal, setShowModal] = useState(false);
    const [selectedClan, setSelectedClan] = useState(null);
    const [isEditing, setIsEditing] = useState(false);
    const [confirmDelete, setConfirmDelete] = useState(null); // Nuevo estado para confirmar eliminación

    async function GetClans() {
        try {
            const response = await axios.get(`${url}Clan`);
            const clansData = response.data;
            setClans(clansData);

            const leaderRequests = clansData.map((clan) =>
                axios.get(`${url}Users/${clan.liderId}`).then((res) => ({
                    id: clan.liderId,
                    name: res.data.username,
                }))
            );

            const leadersData = await Promise.all(leaderRequests);
            const leadersMap = leadersData.reduce((acc, leader) => {
                acc[leader.id] = leader.name;
                return acc;
            }, {});

            setLeaders(leadersMap);
        } catch (error) {
            console.error("Error al obtener los clanes:", error);
        }
    }

    useEffect(() => {
        GetClans();
    }, []);

    const handleEdit = async (id) => {
        try {
            const response = await axios.get(`${url}Clan/${id}`);
            setSelectedClan(response.data);
            setIsEditing(true);
            setShowModal(true);
        } catch (error) {
            console.error("Error al obtener el clan:", error);
        }
    };

    const handleAdd = () => {
        setSelectedClan({ name: "", descripcion: "", liderId: 1, imagenUrl: "" });
        setIsEditing(false);
        setShowModal(true);
    };

    const handleSave = async () => {
        try {
            if (isEditing) {
                await axios.put(`${url}Clan/${selectedClan.id}`, selectedClan);
                setClans(clans.map((clan) => (clan.id === selectedClan.id ? selectedClan : clan)));
            } else {
                const response = await axios.post(`${url}Clan`, selectedClan);
                setClans([...clans, response.data]);
            }
            setShowModal(false);
        } catch (error) {
            console.error("Error al guardar el clan:", error);
        }
    };

    const handleChange = (e) => {
        setSelectedClan({ ...selectedClan, [e.target.name]: e.target.value });
    };

    const handleDelete = (id) => {
        setConfirmDelete(id); // Mostrar confirmación para eliminar
    };

    const confirmDeleteClan = async () => {
        try {
            await axios.delete(`${url}Clan/${confirmDelete}`);
            setClans(clans.filter((clan) => clan.id !== confirmDelete));
            setConfirmDelete(null); // Cerrar la confirmación
        } catch (error) {
            console.error("Error al eliminar el clan:", error);
        }
    };

    const cancelDelete = () => {
        setConfirmDelete(null); // Cancelar la eliminación
    };

    return (
        <div>
            <h2 className="text-2xl font-bold">Explorar Clanes</h2>
            <p>Lista de clanes disponibles...</p>
            <button className="btn btn-success mb-3" onClick={handleAdd}>
                Añadir Clan
            </button>

            <div style={{ overflowX: "auto" }}>
                <table className="table table-striped table-hover">
                    <thead className="table-dark">
                        <tr>
                            <th>Id</th>
                            <th>Nombre</th>
                            <th>Descripción</th>
                            <th>Líder del clan</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        {clans.map((clan) => (
                            <tr key={clan.id}>
                                <td>{clan.id}</td>
                                <td>{clan.name}</td>
                                <td>{clan.descripcion}</td>
                                <td>{leaders[clan.liderId] || "Cargando..."}</td>
                                <td>
                                    <button
                                        className="btn btn-warning me-2"
                                        onClick={() => handleEdit(clan.id)}
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
                                        onClick={() => handleDelete(clan.id)}
                                    >
                                        <img
                                            src="/trash-svgrepo-com.svg"
                                            alt="Eliminar"
                                            width="30"
                                            height="30"
                                        />
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>

            {/* Modal de confirmación para eliminar */}
            {confirmDelete !== null && (
                <div
                    className="modal show fade d-block"
                    tabIndex="-1"
                    style={{ backgroundColor: "rgba(0, 0, 0, 0.5)" }}
                >
                    <div className="modal-dialog">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">¿Estás seguro de eliminar este clan?</h5>
                                <button
                                    type="button"
                                    className="btn-close"
                                    onClick={cancelDelete}
                                ></button>
                            </div>
                            <div className="modal-body">
                                <p>Esta acción no se puede deshacer.</p>
                            </div>
                            <div className="modal-footer">
                                <button
                                    type="button"
                                    className="btn btn-danger"
                                    onClick={confirmDeleteClan}
                                >
                                    Eliminar
                                </button>
                                <button
                                    type="button"
                                    className="btn btn-secondary"
                                    onClick={cancelDelete}
                                >
                                    Cancelar
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            )}

            {/* Modal de edición y creación */}
            <div
                className={`modal fade ${showModal ? "show d-block" : ""}`}
                tabIndex="-1"
                role="dialog"
                style={{ background: showModal ? "rgba(0,0,0,0.5)" : "none" }}
            >
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">
                                {isEditing ? "Editar Clan" : "Añadir Clan"}
                            </h5>
                            <button
                                type="button"
                                className="btn-close"
                                onClick={() => setShowModal(false)}
                            ></button>
                        </div>
                        <div
                            className="modal-body"
                            style={{
                                maxHeight: "400px",
                                overflowY: "auto",
                                scrollbarWidth: "thin", // Esto es para los navegadores que lo soportan
                                paddingRight: "10px", // Espacio para la barra de desplazamiento si es necesario
                            }}
                        >
                            <form>
                                <div className="mb-3">
                                    <label className="form-label">Nombre</label>
                                    <input
                                        type="text"
                                        className="form-control"
                                        name="name"
                                        value={selectedClan?.name || ""}
                                        onChange={handleChange}
                                    />
                                </div>
                                <div className="mb-3">
                                    <label className="form-label">Descripción</label>
                                    <textarea
                                        className="form-control"
                                        name="descripcion"
                                        value={selectedClan?.descripcion || ""}
                                        onChange={handleChange}
                                    />
                                </div>
                                <div className="mb-3">
                                    <label className="form-label">Imagen Url</label>
                                    <textarea
                                        className="form-control"
                                        name="imagenUrl"
                                        value={selectedClan?.imagenUrl || ""}
                                        onChange={handleChange}
                                    />
                                </div>
                            </form>
                        </div>
                        <div className="modal-footer">
                            <button
                                type="button"
                                className="btn btn-secondary"
                                onClick={() => setShowModal(false)}
                            >
                                Cerrar
                            </button>
                            <button
                                type="button"
                                className="btn btn-primary"
                                onClick={handleSave}
                            >
                                Guardar
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Clans;
