import axios from "axios";
import { useState, useEffect } from "react";

function Tournaments() {
    const [tournaments, setTournaments] = useState([]);
    const [modalOpen, setModalOpen] = useState(false);
    const [currentTournament, setCurrentTournament] = useState(null);
    const [form, setForm] = useState({
        name: "",
        description: "",
        startDate: "",
        endDate: "",
        userId: 1, // user fijo por ahora
    });
    const [confirmDelete, setConfirmDelete] = useState(null); // Nuevo estado para confirmar eliminación

    const url = import.meta.env.VITE_API_URL;

    async function getTournaments() {
        try {
            const response = await axios.get(`${url}Tournaments`);
            setTournaments(response.data);
        } catch (error) {
            console.error("Error al obtener torneos:", error);
        }
    }

    useEffect(() => {
        getTournaments();
    }, []);

    const handleDelete = (id) => {
        setConfirmDelete(id); // Mostrar confirmación para eliminar
    };

    const confirmDeleteTournament = async () => {
        try {
            await axios.delete(`${url}Tournaments/${confirmDelete}`);
            setTournaments(tournaments.filter((t) => t.id !== confirmDelete));
            setConfirmDelete(null); // Cerrar la confirmación
        } catch (error) {
            console.error("Error al eliminar torneo:", error);
        }
    };

    const cancelDelete = () => {
        setConfirmDelete(null); // Cancelar la eliminación
    };

    const handleEdit = (tournament) => {
        setCurrentTournament(tournament);
        setForm({
            ...tournament,
            userId: 1, // fuerza el userId
        });
        setModalOpen(true);
    };

    const handleCreate = () => {
        setCurrentTournament(null);
        setForm({
            name: "",
            description: "",
            startDate: "",
            endDate: "",
            userId: 1,
        });
        setModalOpen(true);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();

        const formattedForm = {
            ...form,
            startDate: new Date(form.startDate).toISOString(),
            endDate: new Date(form.endDate).toISOString(),
            userId: 1, // fuerza user fijo
        };

        try {
            if (currentTournament) {
                await axios.put(
                    `${url}Tournaments/${currentTournament.id}`,
                    formattedForm
                );
            } else {
                await axios.post(`${url}Tournaments`, formattedForm);
            }
            setModalOpen(false);
            getTournaments();
        } catch (error) {
            console.error("Error al guardar torneo:", error.response?.data || error);
        }
    };

    return (
        <div>
            <h2 className="text-2xl font-bold">Torneos</h2>
            <button className="btn btn-success mb-3" onClick={handleCreate}>
                Crear nuevo Torneo
            </button>
            <table className="table table-striped table-hover">
                <thead className="table-dark">
                    <tr>
                        <th>Nombre</th>
                        <th>Descripción</th>
                        <th>Fecha de inicio</th>
                        <th>Fecha de finalización</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    {tournaments.map((torneo) => (
                        <tr key={torneo.id}>
                            <td>{torneo.name}</td>
                            <td>{torneo.description}</td>
                            <td>{new Date(torneo.startDate).toLocaleDateString()}</td>
                            <td>{new Date(torneo.endDate).toLocaleDateString()}</td>
                            <td>
                                <button
                                    className="btn btn-warning me-2"
                                    onClick={() => handleEdit(torneo)}
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
                                    onClick={() => handleDelete(torneo.id)}
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

            {modalOpen && (
                <div
                    className="modal show fade d-block"
                    tabIndex="-1"
                    style={{ backgroundColor: "rgba(0, 0, 0, 0.5)" }}
                >
                    <div className="modal-dialog">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">
                                    {currentTournament ? "Editar Torneo" : "Crear Torneo"}
                                </h5>
                                <button
                                    type="button"
                                    className="btn-close"
                                    onClick={() => setModalOpen(false)}
                                ></button>
                            </div>
                            <form onSubmit={handleSubmit}>
                                <div className="modal-body">
                                    <div className="mb-3">
                                        <label className="form-label">Nombre</label>
                                        <input
                                            type="text"
                                            className="form-control"
                                            value={form.name}
                                            onChange={(e) =>
                                                setForm({ ...form, name: e.target.value })
                                            }
                                            required
                                            maxLength={50}
                                        />
                                        {form.name.length > 50 && (
                                            <div className="text-danger">
                                                Máximo 50 caracteres permitidos.
                                            </div>
                                        )}
                                    </div>
                                    <div className="mb-3">
                                        <label className="form-label">Descripción</label>
                                        <input
                                            type="text"
                                            className="form-control"
                                            value={form.description}
                                            onChange={(e) =>
                                                setForm({ ...form, description: e.target.value })
                                            }
                                            required
                                            maxLength={200}
                                        />
                                        {form.description.length > 200 && (
                                            <div className="text-danger">
                                                Máximo 200 caracteres permitidos.
                                            </div>
                                        )}
                                    </div>
                                    <div className="mb-3">
                                        <label className="form-label">Fecha de inicio</label>
                                        <input
                                            type="date"
                                            className="form-control"
                                            value={form.startDate}
                                            onChange={(e) =>
                                                setForm({ ...form, startDate: e.target.value })
                                            }
                                            required
                                        />
                                    </div>
                                    <div className="mb-3">
                                        <label className="form-label">Fecha de finalización</label>
                                        <input
                                            type="date"
                                            className="form-control"
                                            value={form.endDate}
                                            onChange={(e) =>
                                                setForm({ ...form, endDate: e.target.value })
                                            }
                                            required
                                        />
                                        {form.startDate &&
                                            form.endDate &&
                                            new Date(form.endDate) < new Date(form.startDate) && (
                                                <div className="text-danger">
                                                    La fecha de finalización no puede ser anterior a la de
                                                    inicio.
                                                </div>
                                            )}
                                    </div>
                                </div>
                                <div className="modal-footer">
                                    <button
                                        type="submit"
                                        className="btn btn-primary"
                                        disabled={
                                            !form.name ||
                                            !form.description ||
                                            !form.startDate ||
                                            !form.endDate ||
                                            form.name.length > 50 ||
                                            form.description.length > 200 ||
                                            new Date(form.endDate) < new Date(form.startDate)
                                        }
                                    >
                                        Guardar
                                    </button>
                                    <button
                                        type="button"
                                        className="btn btn-secondary"
                                        onClick={() => setModalOpen(false)}
                                    >
                                        Cancelar
                                    </button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            )}

            {/* Confirmación para eliminar torneo */}
            {confirmDelete !== null && (
                <div
                    className="modal show fade d-block"
                    tabIndex="-1"
                    style={{ backgroundColor: "rgba(0, 0, 0, 0.5)" }}
                >
                    <div className="modal-dialog">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">¿Estás seguro de eliminar este torneo?</h5>
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
                                    onClick={confirmDeleteTournament}
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

        </div>
    );
}

export default Tournaments;
