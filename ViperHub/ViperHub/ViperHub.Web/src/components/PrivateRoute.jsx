// src/components/PrivateRoute.jsx
import React from "react";
import { Navigate } from "react-router-dom";

const PrivateRoute = ({ children }) => {
    const userId = localStorage.getItem("userId");

    if (!userId) {
        return <Navigate to="/login" />;
    }

    return children;
};

export default PrivateRoute;
