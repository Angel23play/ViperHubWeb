// src/pages/Settings.jsx
function Settings({ apiUrl }) {
  let url = `${import.meta.env.VITE_API_URL}`;
  return (
    <div>
      <h2 className="text-2xl font-bold">Configuracion</h2>
      <p>Ajustes de la cuenta...</p>
    </div>
  );
}

export default Settings;
