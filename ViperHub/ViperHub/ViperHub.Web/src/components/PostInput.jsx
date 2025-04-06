import axios from "axios";
import React, { useState, useEffect } from "react";

function PostInput({ handle, postId }) {
  const [title, setTitle] = useState("");
  const [content, setContent] = useState("");
  const [categories, setCategories] = useState([]);
  const [categorySelected, setCategorySelected] = useState("");
  const [errors, setErrors] = useState({});
  let url = `${import.meta.env.VITE_API_URL}`;

  useEffect(() => {
    async function fetchData() {
      try {
        const response = await axios.get(`${url}CategoryForo`);
        setCategories(response.data);
      } catch (error) {
        console.error("Error al obtener categorías:", error);
      }
    }

    async function fetchTheme() {
      if (handle === 1 && postId) {
        try {
          const response = await axios.get(`${url}Themes/${postId}`);
          setTitle(response.data.title);
          setContent(response.data.content);
          setCategorySelected(response.data.categoriaForoId);
        } catch (error) {
          console.error("Error al obtener el post:", error);
        }
      }
    }

    fetchData();
    fetchTheme();
  }, [url, handle, postId]);

  const validateForm = () => {
    let newErrors = {};
    if (!title.trim()) newErrors.title = "El título es obligatorio";
    if (!content.trim()) newErrors.content = "El contenido es obligatorio";
    if (!categorySelected)
      newErrors.categorySelected = "Selecciona una categoría";
    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!validateForm()) return;

    try {
      if (handle === 0) {
        const data = {
          title,
          content,
          usuarioId: 1,
          categoriaForoId: categorySelected,
          dateCreation: new Date().toISOString(),
        };

        await axios.post(`${url}Themes`, data);
      } else {
        const data = {
          id: postId,
          title,
          content,
          usuarioId: 1,
          categoriaForoId: parseInt(categorySelected),
        };
        console.log(data);
        await axios.put(`${url}Themes/${postId}`, data);
      }

      console.log("Publicación exitosa");
      setTitle("");
      setContent("");
      setCategorySelected("");
      setErrors({});
    } catch (error) {
      console.error("Error al publicar:", error.response?.data || error);
    }
  };

  return (
    <div className="mb-4">
      <form onSubmit={handleSubmit}>
        <label>Título de la publicación</label>
        <input
          className={`form-control ${errors.title ? "is-invalid" : ""}`}
          type="text"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
        />
        {errors.title && <div className="text-danger">{errors.title}</div>}

        <textarea
          className={`form-control ${errors.content ? "is-invalid" : ""}`}
          rows="3"
          placeholder="Escribe una nueva publicación..."
          value={content}
          onChange={(e) => setContent(e.target.value)}
        />
        <select
          className={`form-select ${
            errors.categorySelected ? "is-invalid" : ""
          }`}
          id="gameSelect"
          value={categorySelected}
          onChange={(e) => setCategorySelected(e.target.value)}
        >
          <option value="">Elige una opción...</option>
          {Array.isArray(categories) &&
            categories.map((category) => (
              <option key={category.id} value={category.id}>
                {category.name}
              </option>
            ))}
        </select>
        {errors.content && <div className="text-danger">{errors.content}</div>}

        <button type="submit" className="btn btn-success mt-2 w-100">
          {handle === 0 ? "Publicar" : "Actualizar"}
        </button>
      </form>
    </div>
  );
}

export default PostInput;
