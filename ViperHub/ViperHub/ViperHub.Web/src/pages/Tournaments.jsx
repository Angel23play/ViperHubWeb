import axios from "axios";
import { useState, useEffect } from "react";

function Tournaments() {
  const [tournaments, setTournaments] = useState([]);
  const [user, setUser] = useState([]);
  const url = import.meta.env.VITE_API_URL;

  async function getTournaments() {
    try {
      const response = await axios.get(`${url}Tournaments`);
      setTournaments(response.data);
      console.log(response.data);
    } catch (error) {
      console.error("Error al obtener torneos:", error);
    }
  }
  useEffect(() => {
    getTournaments();
  }, []);

  return (
    <div>
      <h2 className="text-2xl font-bold">Torneos</h2>
      
      <p>Lista de torneos...</p>

      <button className="btn btn-success mb-3">Crear nuevo Torneo</button>

      <table className="table table-striped table-hover">
        <thead className="table-dark">
          <tr>
            <th>Nombre</th>
            <th>Descripción</th>
            <th>Fecha de inicio</th>
            <th>Fecha de finalización</th>
            <th>Creado por</th>
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
              <td>{torneo.createdBy || "Desconocido"}</td>
              <td>
                <div>
                  <button
                    className="btn btn-warning me-2"
                    onClick={() => handleEdit(torneo.id)}
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
                </div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Tournaments;
