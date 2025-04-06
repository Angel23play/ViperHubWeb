import { useState, useEffect } from "react";
import axios from "axios";

function Clans() {
  let url = `${import.meta.env.VITE_API_URL}`;

  async function GetClans() {
    axios.get();
  }

  return (
    <div>
      <h2 className="text-2xl font-bold">Explorar Clanes</h2>
      <p>Lista de clanes disponibles...</p>
      <table>
        <thead>
          <th>Id</th>
          <th>Nombre</th>
          <th>Descripcion</th>
          <th>Nombre del lider</th>
        </thead>
      </table>
    </div>
  );
}

export default Clans;
