import axios from "axios";
import { useState, useEffect } from "react";

function HomeView({ url, viewName }) {
    const [data, setData] = useState(null);
    const [headers, setHeaders] = useState([]);

    // Funcion para obtener datos desde la API
    async function getApi() {
        try {
            const response = await axios.get(url);
            setData(response.data);

            // Suponiendo que la respuesta tiene al menos un objeto y el primer objeto tiene las claves como headers
            if (response.data.length > 0) {
                setHeaders(Object.keys(response.data[0]));
            }
        } catch (error) {
            console.error(error);
        }
    }

    // Llamada a la API cuando el componente se monta
    useEffect(() => {
        getApi();
    }, [url]);  

    return (
        <div className="container mt-4">
            <h2 className="text-center mb-3">Listado de {viewName}</h2>
            <div className="d-flex justify-content-end mb-3">
                <button className="btn btn-primary">A�adir</button>
            </div>
            <div className="table-responsive">
                <table className="table table-striped table-hover table-bordered">
                    <thead className="table-dark">
                        <tr>
                            {/* Mapeamos los headers para mostrarlos como titulos de la tabla */}
                            {headers.map((header, idx) => (
                                <th key={idx} className="text-center">{header}</th>
                            ))}
                            <th className="text-center">Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        {/* Mapeamos los datos para mostrarlos en las filas */}
                        {data && data.map((item, index) => (
                            <tr key={index}>
                                {headers.map((header, idx) => (
                                    <td key={idx} className="text-center">{item[header]}</td>
                                ))}
                                <td className="text-center">
                                    <button className="btn btn-warning btn-sm me-2">Editar</button>
                                    <button className="btn btn-danger btn-sm">Eliminar</button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default HomeView;
