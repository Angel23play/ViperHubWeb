import React, { useState, useEffect } from "react";
import axios from "axios";

function Profile({ user }) {
  const [showConfirm, setShowConfirm] = useState(false);
  const [showChangePassword, setShowChangePassword] = useState(false);
  const [showEditUser, setShowEditUser] = useState(false);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  // Para cambiar contraseña
  const [newPassword, setNewPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  // Para editar usuario
  const [updatedUser, setUpdatedUser] = useState({
    firstName: user.firstName,
    lastName: user.lastName,
    username: user.username,
    email: user.email,
    registerDate: user.registerDate,
  });

  // Guardamos la contraseña original para reenviarla en el PUT de editar usuario
  const [originalPassword, setOriginalPassword] = useState("");

  const url = import.meta.env.VITE_API_URL;

  if (!user) return <p>Cargando perfil...</p>;

  const token = localStorage.getItem("token");
  if (!token) {
    window.location.href = "/login";
    return null;
  }

  const handleLogout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("userId");
    window.location.href = "/";
  };

  const handleDeleteAccount = async () => {
    setError(null);
    setLoading(true);
    try {
      await axios.delete(`${url}Users/${user.id}`, {
        headers: { Authorization: `Bearer ${token}` },
      });
      handleLogout();
    } catch (err) {
      setError("Error al eliminar la cuenta.");
    } finally {
      setLoading(false);
    }
  };

  // Antes de abrir el modal de "Editar usuario" traemos la contraseña actual
  const openEditUser = async () => {
    setError(null);
    setLoading(true);
    try {
      const res = await axios.get(`${url}Users/${user.id}/password`); // solo la contraseña
      setOriginalPassword(res.data);
      setShowEditUser(true);
    } catch (err) {
      setError("No se pudo obtener la contraseña actual.");
    } finally {
      setLoading(false);
    }
  };

  // PUT para editar solo datos de usuario (sin tocar password)
  const handleEditUser = async () => {
    setError(null);

    setLoading(true);
    try {
      await axios.put(
        `${url}Users/${user.id}`,
        {
          firstName: updatedUser.firstName,
          lastName:  updatedUser.lastName,
          email:     updatedUser.email,
          username:  updatedUser.username,
          password:  originalPassword,     
          registerDate: updatedUser.registerDate
        },
        { headers: { Authorization: `Bearer ${token}` } }
      );
      alert("Usuario actualizado correctamente.");
      setShowEditUser(false);
    } catch (err) {
      setError("No se pudo actualizar el usuario.");
    } finally {
      setLoading(false);
    }
  };

  // PUT para cambiar solo contraseña
  const handleChangePassword = async () => {
    setError(null);
    if (newPassword !== confirmPassword) {
      setError("Las contraseñas no coinciden.");
      return;
    }
    setLoading(true);
    try {
      await axios.put(
        `${url}Users/${user.id}`,
        {
          password: newPassword,
          username: updatedUser.username,
          email:    updatedUser.email,
          firstName: updatedUser.firstName,
          lastName:  updatedUser.lastName,
          registerDate: updatedUser.registerDate
        },
        { headers: { Authorization: `Bearer ${token}` } }
      );
      alert("Contraseña cambiada correctamente.");
      setShowChangePassword(false);
      setNewPassword("");
      setConfirmPassword("");
      // actualizamos también la original para futuras ediciones
      setOriginalPassword(newPassword);
    } catch (err) {
      setError("No se pudo cambiar la contraseña.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="card my-4 p-4 shadow rounded-xl bg-white">
      <h3 className="text-xl mb-4">Perfil del Usuario</h3>

      <p><strong>Nombre:</strong> {user.firstName}</p>
      <p><strong>Apellido:</strong> {user.lastName}</p>
      <p><strong>Usuario:</strong> {user.username}</p>
      <p><strong>Email:</strong> {user.email}</p>
      <p><strong>Registro:</strong> {new Date(user.registerDate).toLocaleDateString()}</p>

      <button onClick={handleLogout} className="btn btn-danger w-full mt-3">
        Cerrar sesión
      </button>
      <button onClick={() => setShowChangePassword(true)} className="btn btn-primary w-full mt-2">
        Cambiar contraseña
      </button>
      <button onClick={openEditUser} className="btn btn-warning w-full mt-2">
        Editar datos
      </button>
      <button onClick={() => setShowConfirm(true)} className="btn btn-danger w-full mt-2">
        Eliminar cuenta
      </button>

      {error && <div className="alert alert-danger mt-3">{error}</div>}

      {/* Modal Cambiar Contraseña */}
      {showChangePassword && (
        <div className="mt-4 p-4 bg-yellow-100 rounded">
          <h5>Cambiar Contraseña</h5>
          <input
            type="password"
            className="form-control my-2"
            placeholder="Nueva contraseña"
            value={newPassword}
            onChange={e => setNewPassword(e.target.value)}
          />
          <input
            type="password"
            className="form-control my-2"
            placeholder="Confirmar contraseña"
            value={confirmPassword}
            onChange={e => setConfirmPassword(e.target.value)}
          />
          <button onClick={handleChangePassword} className="btn btn-success w-full my-2" disabled={loading}>
            {loading ? "Cambiando..." : "Cambiar contraseña"}
          </button>
          <button onClick={() => { setShowChangePassword(false); setError(null); }} className="btn btn-secondary w-full">
            Cancelar
          </button>
        </div>
      )}

      {/* Modal Editar Usuario */}
      {showEditUser && (
        <div className="mt-4 p-4 bg-blue-100 rounded">
          <h5>Editar datos</h5>
          <input
            className="form-control my-2"
            value={updatedUser.firstName}
            onChange={e => setUpdatedUser({ ...updatedUser, firstName: e.target.value })}
            placeholder="Nombre"
          />
          <input
            className="form-control my-2"
            value={updatedUser.lastName}
            onChange={e => setUpdatedUser({ ...updatedUser, lastName: e.target.value })}
            placeholder="Apellido"
          />
          <input
            className="form-control my-2"
            value={updatedUser.username}
            onChange={e => setUpdatedUser({ ...updatedUser, username: e.target.value })}
            placeholder="Usuario"
          />
          <input
            className="form-control my-2"
            value={updatedUser.email}
            onChange={e => setUpdatedUser({ ...updatedUser, email: e.target.value })}
            placeholder="Email"
            type="email"
          />
          <button onClick={handleEditUser} className="btn btn-success w-full my-2" disabled={loading}>
            {loading ? "Guardando..." : "Guardar cambios"}
          </button>
          <button onClick={() => { setShowEditUser(false); setError(null); }} className="btn btn-secondary w-full">
            Cancelar
          </button>
        </div>
      )}

      
      {showConfirm && (
        <div className="mt-4 p-4 bg-red-100 rounded">
          <h5>Eliminar cuenta</h5>
          <p>¿Estás seguro? Esta acción no se puede deshacer.</p>
          <button onClick={handleDeleteAccount} className="btn btn-danger w-full my-2" disabled={loading}>
            {loading ? "Eliminando..." : "Eliminar cuenta"}
          </button>
          <button onClick={() => setShowConfirm(false)} className="btn btn-secondary w-full">
            Cancelar
          </button>
        </div>
      )}
    </div>
  );
}

export default Profile;
