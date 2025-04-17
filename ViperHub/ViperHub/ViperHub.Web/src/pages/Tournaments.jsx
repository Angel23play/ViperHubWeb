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
  });
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

  const handleDelete = async (id) => {
    try {
      await axios.delete(`${url}Tournaments/${id}`);
      setTournaments(tournaments.filter((t) => t.id !== id));
    } catch (error) {
      console.error("Error al eliminar torneo:", error);
    }
  };

  const handleEdit = (tournament) => {
    setCurrentTournament(tournament);
    setForm(tournament);
    setModalOpen(true);
  };

  const handleCreate = () => {
    setCurrentTournament(null);
    setForm({ name: "", description: "", startDate: "", endDate: "" });
    setModalOpen(true);
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      if (currentTournament) {
        await axios.put(`${url}Tournaments/${currentTournament.id}`, form);
      } else {
        await axios.post(`${url}Tournaments`, form);
      }
      setModalOpen(false);
      getTournaments();
    } catch (error) {
      console.error("Error al guardar torneo:", error);
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
                  Editar
                </button>
                <button
                  className="btn btn-danger"
                  onClick={() => handleDelete(torneo.id)}
                >
                  Eliminar
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      {modalOpen && (
        <div className="modal">
          <div className="modal-content">
            <h3>{currentTournament ? "Editar Torneo" : "Crear Torneo"}</h3>
            <form onSubmit={handleSubmit}>
              <input
                type="text"
                placeholder="Nombre"
                value={form.name}
                onChange={(e) => setForm({ ...form, name: e.target.value })}
                required
              />
              <input
                type="text"
                placeholder="Descripción"
                value={form.description}
                onChange={(e) =>
                  setForm({ ...form, description: e.target.value })
                }
                required
              />
              <input
                type="date"
                value={form.startDate}
                onChange={(e) =>
                  setForm({ ...form, startDate: e.target.value })
                }
                required
              />
              <input
                type="date"
                value={form.endDate}
                onChange={(e) => setForm({ ...form, endDate: e.target.value })}
                required
              />
              <button type="submit" className="btn btn-primary">
                Guardar
              </button>
              <button
                type="button"
                className="btn btn-secondary"
                onClick={() => setModalOpen(false)}
              >
                Cancelar
              </button>
            </form>
          </div>
        </div>
      )}
    </div>
  );
}

export default Tournaments;
