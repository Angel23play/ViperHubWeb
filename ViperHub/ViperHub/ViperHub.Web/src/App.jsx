import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import MainLayout from "./components/MainLayout";
import Feed from "./pages/Feed";
import Clans from "./pages/Clans";
import Tournaments from "./pages/Tournaments";
import Settings from "./pages/Settings";
import Login from "./pages/Login";
import Register from "./pages/Register"; // <-- Nueva ruta
import PrivateRoute from "./components/PrivateRoute";
import Categories from "./components/Categories"; // <-- Corrige si estaba mal ubicado

const App = () => {
    return (
        <Router>
            <Routes>
                {/* Rutas públicas */}
                <Route path="/login" element={<Login />} />
                <Route path="/register" element={<Register />} />

                {/* Rutas protegidas */}
                <Route
                    path="/"
                    element={
                        <PrivateRoute>
                            <MainLayout />
                        </PrivateRoute>
                    }
                >
                    <Route index element={<Feed />} />
                    <Route path="clans" element={<Clans />} />
                    <Route path="tournaments" element={<Tournaments />} />
                    <Route path="settings" element={<Settings />} />
                    <Route path="categories" element={<Categories />} />
                </Route>
            </Routes>
        </Router>
    );
};

export default App;
