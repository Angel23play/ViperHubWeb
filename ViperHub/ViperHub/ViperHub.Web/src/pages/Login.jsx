import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const navigate = useNavigate();
  const url = `${import.meta.env.VITE_API_URL}`;
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(null); // Limpiar error anterior

    try {
      // Realiza la petición de login
      const response = await axios.post(`${url}Auth/login`, {
        username,
        password,
      });

      // Verifica la respuesta del backend
      const { token, id } = response.data;

      if (token && id) {
        // Si el token y el userId están presentes, guarda en localStorage
        localStorage.setItem("token", token);
        localStorage.setItem("userId", id);

        // Redirige a la página principal
        navigate("/");
      } else {
        setError("Respuesta inválida del servidor.");
        console.log(response.data); // Verificar los datos de la respuesta
      }
    } catch (err) {
      // En caso de error, muestra el mensaje adecuado
      setError("Usuario o contraseña incorrectos.");
    }
  };

  return (
    <div className="d-flex align-items-center justify-content-center vh-100 bg-light">
      <div className="card shadow-lg p-4" style={{ width: "350px" }}>
        <h3 className="text-center mb-4">Iniciar Sesión</h3>
        {error && <div className="alert alert-danger">{error}</div>}
        <form onSubmit={handleSubmit}>
          <div className="mb-3">
            <label htmlFor="username" className="form-label">
              Nombre de Usuario
            </label>
            <input
              type="text"
              className="form-control"
              id="username"
              value={username}
              onChange={(e) => {
                setUsername(e.target.value);
                setError(null); // Limpiar error cuando el usuario cambia los datos
              }}
              placeholder="Ingrese su nombre de usuario"
              required
            />
          </div>
          <div className="mb-3">
            <label htmlFor="password" className="form-label">
              Contraseña
            </label>
            <input
              type="password"
              className="form-control"
              id="password"
              value={password}
              onChange={(e) => {
                setPassword(e.target.value);
                setError(null); // Limpiar error cuando el usuario cambia los datos
              }}
              placeholder="Ingrese su contraseña"
              required
            />
          </div>
          <button type="submit" className="btn btn-primary w-100">
            Ingresar
          </button>
        </form>
        <div className="text-center mt-3">
          <p className="mt-4 text-center">
            ¿No tienes cuenta?{" "}
            <a href="/register" className="text-blue-500 hover:underline">
              Regístrate aquí
            </a>
          </p>
        </div>
      </div>
    </div>
  );
};

export default Login;
