
import React from "react";

const Footer = () => {
    return (
        <footer className="border-top bg-light py-3 w-100 position-fixed bottom-0 bg">
            <div className="container d-flex flex-column flex-md-row justify-content-between align-items-center">
                <p className="mb-2 mb-md-0 text-muted fs-6 text-center text-md-start"> 2024 ViperHub, Inc.</p>
                <a href="/" className="d-flex align-items-center text-dark text-decoration-none mb-2 mb-md-0">

                </a>
                <ul className="nav justify-content-center justify-content-md-end fs-6">
                    <li className="nav-item"><a href="#" className="nav-link px-2 text-muted"><img src="/home-1-svgrepo-com.svg" alt="icon-home" width="50" height="40" /></a></li>
                    <li className="nav-item"><a href="#" className="nav-link px-2 text-muted"><img src="/shield-svgrepo-com.svg" alt="icon-clans"width="50" height="40"  /></a></li>
                    <li className="nav-item"><a href="#" className="nav-link px-2 text-muted"><img src="/trophy-svgrepo-com.svg" alt="icon-clans"width="50" height="40"  /></a></li>
                    <li className="nav-item"><a href="#" className="nav-link px-2 text-muted"><img src="/settings-svgrepo-com.svg" alt="icon-clans"width="50" height="40"  /></a></li>
                </ul>
            </div>
        </footer>
    );
};

export default Footer;
