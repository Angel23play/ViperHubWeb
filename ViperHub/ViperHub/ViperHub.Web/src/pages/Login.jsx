import React from "react";

const Login = () => {
  let url = `${import.meta.env.VITE_API_URL}`;
  
  return (
    <div className="d-flex align-items-center justify-content-center vh-100 bg-light">
      <div className="card shadow-lg p-4" style={{ width: "350px" }}>
        <h3 className="text-center mb-4">Iniciar Sesión</h3>
        <form>
          <div className="mb-3">
            <label htmlFor="email" className="form-label">Correo Electrónico</label>
            <input type="email" className="form-control" id="email" placeholder="Ingrese su correo" required />
          </div>
          <div className="mb-3">
            <label htmlFor="password" className="form-label">Contraseña</label>
            <input type="password" className="form-control" id="password" placeholder="Ingrese su contraseña" required />
          </div>
          <button type="submit" className="btn btn-primary w-100">Ingresar</button>
        </form>
        <div className="text-center mt-3">
          <a href="#">¿Olvidaste tu contraseña?</a>
        </div>
      </div>
    </div>
  );
};

export default Login;