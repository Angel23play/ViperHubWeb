import { useEffect, useState } from "react";
import Profile from "../components/Profile";
import axios from "axios";
import { jwtDecode } from "jwt-decode";

function Settings() {
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [darkMode, setDarkMode] = useState(
    localStorage.getItem("theme") === "dark"
  );

  const url = `${import.meta.env.VITE_API_URL}`;

  // Obtener userId desde el token
  const getUserIdFromToken = () => {
    const token = localStorage.getItem("token");
    if (!token) return null;

    try {
      const decoded = jwtDecode(token);
      return decoded?.userId || decoded?.id || null;
    } catch (error) {
      console.error("Error al decodificar el token:", error);
      return null;
    }
  };

  // Obtener datos del usuario
  useEffect(() => {
    async function fetchUser() {
      const userId = getUserIdFromToken();
      if (!userId) {
        setError("No se encontró el usuario en el token.");
        setLoading(false);
        return;
      }

      try {
        const response = await axios.get(`${url}Users/${userId}`);
        setUser(response.data);
      } catch (err) {
        console.error("Error al obtener usuario:", err);
        setError("No se pudo cargar la información del usuario.");
      } finally {
        setLoading(false);
      }
    }

    fetchUser();
  }, [url]);

  // Aplicar tema oscuro si está activado
  useEffect(() => {
    const body = document.body;
    if (darkMode) {
      body.classList.add("bg-dark", "text-light");
      localStorage.setItem("theme", "dark");
    } else {
      body.classList.remove("bg-dark", "text-light");
      localStorage.setItem("theme", "light");
    }
  }, [darkMode]);

  return (
    <div className="p-4">
      <h2 className="text-2xl font-bold mb-2">Configuración</h2>
      <p className="mb-4">Ajustes de la cuenta...</p>

      {loading && <p>Cargando perfil...</p>}
      {error && <p className="text-red-500">{error}</p>}
      {user && <Profile user={user} />}
    </div>
  );
}

export default Settings;
