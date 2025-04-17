
import { Outlet } from "react-router-dom";
import Navbar from "./Navbar";
import Footer from "./Footer";

function MainLayout() {

    
    return (
        <>
            <Navbar />
            <div className="container my-4">
                <Outlet />  
            </div>
            <Footer />
        </>
    );
}

export default MainLayout;
