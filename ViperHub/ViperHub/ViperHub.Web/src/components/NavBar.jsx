import { useState, useEffect } from "react";
import { Link } from "react-router-dom";

function Navbar() {
    const [darkMode, setDarkMode] = useState(localStorage.getItem("theme") === "dark");

    useEffect(() => {
        const body = document.body;
        if (darkMode) {
            body.classList.add("bg-dark", "text-light"); // Activa el modo oscuro
            localStorage.setItem("theme", "dark");
        } else {
            body.classList.remove("bg-dark", "text-light"); // Vuelve al modo claro
            localStorage.setItem("theme", "light");
        }
    }, [darkMode]);

    return (
        <nav className={`navbar navbar-expand-lg ${darkMode ? "navbar-dark bg-dark" : "navbar-light bg-light"}`}>
            <div className="container">
                <a className="navbar-brand" href="/">
                    <img src="/dist/ViperHuB.svg" alt="Logo" />ViperHub
                </a>
                <button
                    className="navbar-toggler"
                    type="button"
                    data-bs-toggle="collapse"
                    data-bs-target="#navbarNav"
                    aria-controls="navbarNav"
                    aria-expanded="false"
                    aria-label="Toggle navigation"
                >
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav ms-auto">
                        <li className="nav-item">
                            <Link className="nav-link" to="/">
                                Inicio
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/clans">
                                Clanes
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/tournaments">
                                Torneos
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/settings">
                                Configuracion
                            </Link>
                        </li>
                        <li className="nav-item">
                            <button
                                className="btn btn-outline-light d-flex align-items-center justify-content-center"
                                onClick={() => setDarkMode(!darkMode)}
                            >
                                {/* Sol (modo claro) */}
                                {darkMode ? (
                                    <img src="/dist/sun-svgrepo-com.svg" alt="Luna" width="50" height="40" />
                                ) : (
                                        <img src="/dist/moon-stars-svgrepo-com.svg" alt = "icon-clans" width="50" height="40" />
                                )}
                            </button>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
}

export default Navbar;
