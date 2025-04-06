import { useState, useEffect } from "react";
import axios from "axios";

function Clans() {
  const url = import.meta.env.VITE_API_URL;
  const [clans, setClans] = useState([]);
  const [leaders, setLeaders] = useState({});

  async function GetClans() {
    try {
      const response = await axios.get(`${url}Clan`);
      const clansData = response.data;
      setClans(clansData);

      // Obtener los líderes de cada clan en paralelo
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

  const handleEdit = (id) => {
    console.log(`Editar clan con ID: ${id}`);
    // Aquí puedes redirigir o abrir un modal para editar
  };

  const handleDelete = async (id) => {
    if (!window.confirm("¿Estás seguro de eliminar este clan?")) return;

    try {
      await axios.delete(`${url}Clan/${id}`);
      setClans(clans.filter((clan) => clan.id !== id));
    } catch (error) {
      console.error("Error al eliminar el clan:", error);
    }
  };

  return (
    <div>
      <h2 className="text-2xl font-bold">Explorar Clanes</h2>

      <p>Lista de clanes disponibles...</p>

      <button className="btn btn-success mb-3">Crear nuevo Clan</button>

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
                <div>
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
                </div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Clans;
