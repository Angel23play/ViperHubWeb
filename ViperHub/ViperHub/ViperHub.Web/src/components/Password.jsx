import { useState } from "react";
import axios from "axios";

const Password = () => {
    const [currentPassword, setCurrentPassword] = useState("");
    const [newPassword, setNewPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [error, setError] = useState("");
    const [success, setSuccess] = useState("");
    let url = `${import.meta.env.VITE_API_URL}`;

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError("");
        setSuccess("");

        if (newPassword !== confirmPassword) {
            setError("Las contrase�as no coinciden.");
            return;
        }

        try {
            await axios.post`${ url }User`, {
              currentPassword,
              newPassword
            });
            setSuccess("Contrase�a actualizada con �xito.");
            setCurrentPassword("");
            setNewPassword("");
            setConfirmPassword("");
        } catch (err) {
            setError(`Hubo un error al cambiar la contrase�a. ${err}`);
        }
    };

    return (
        <div className="p-4 bg-white rounded shadow max-w-md mx-auto">
            <h2 className="text-xl font-bold mb-4">Cambiar Contrase�a</h2>
            <form onSubmit={handleSubmit} className="space-y-4">
                <input
                    type="password"
                    placeholder="Contrase�a actual"
                    className="w-full border p-2 rounded"
                    value={currentPassword}
                    onChange={(e) => setCurrentPassword(e.target.value)}
                    required
                />
                <input
                    type="password"
                    placeholder="Nueva contrase�a"
                    className="w-full border p-2 rounded"
                    value={newPassword}
                    onChange={(e) => setNewPassword(e.target.value)}
                    required
                />
                <input
                    type="password"
                    placeholder="Confirmar nueva contrase�a"
                    className="w-full border p-2 rounded"
                    value={confirmPassword}
                    onChange={(e) => setConfirmPassword(e.target.value)}
                    required
                />
                {error && <p className="text-red-500">{error}</p>}
                {success && <p className="text-green-500">{success}</p>}
                <button
                    type="submit"
                    className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
                >
                    Cambiar contrase�a
                </button>
            </form>
        </div>
    );
};

export default Password;
