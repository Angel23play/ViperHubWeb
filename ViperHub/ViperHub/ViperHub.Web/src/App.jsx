import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import MainLayout from "./components/MainLayout";
import Feed from "./pages/Feed";
import Profile from "./pages/Profile";
import Clans from "./pages/Clans";
import Tournaments from "./pages/Tournaments";
import Settings from "./pages/Settings";

const App = () => {


    return (
        <Router>
            <Routes>
                <Route path="/" element={<MainLayout />}>
                    <Route index element={<Feed />} />
                    <Route path="profile" element={<Profile />} />
                    <Route path="clans" element={<Clans />} />
                    <Route path="tournaments" element={<Tournaments />} />
                    <Route path="settings" element={<Settings />} />
                </Route>
            </Routes>
        </Router>
    );
};

export default App;
