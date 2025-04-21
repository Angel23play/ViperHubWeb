import { useState } from "react";

function Categories() {
  const [categories, setCategories] = useState([]);
  const [newCategory, setNewCategory] = useState("");
  const [editingCategory, setEditingCategory] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [categoryName, setCategoryName] = useState("");

  const handleAddCategory = () => {
    if (newCategory.trim() === "") {
      alert("La categoría no puede estar vacía.");
      return;
    }
    setCategories([...categories, newCategory]);
    setNewCategory("");
  };

  const handleDeleteCategory = (index) => {
    const updatedCategories = categories.filter((_, i) => i !== index);
    setCategories(updatedCategories);
  };

  const handleEditCategory = (category, index) => {
    setEditingCategory(index);
    setCategoryName(category);
    setShowModal(true);
  };

  const handleSaveCategory = () => {
    if (categoryName.trim() === "") {
      alert("El nombre de la categoría no puede estar vacío.");
      return;
    }
    const updatedCategories = categories.map((category, index) =>
      index === editingCategory ? categoryName : category
    );
    setCategories(updatedCategories);
    setShowModal(false);
    setEditingCategory(null);
    setCategoryName("");
  };

  return (
    <div className="p-4">
      <h2 className="text-2xl font-bold mb-2">Gestión de Categorías</h2>
      <p className="mb-4">Añadir, editar o eliminar categorías.</p>

      <div className="flex gap-2 mb-2">
        <input
          type="text"
          value={newCategory}
          onChange={(e) => setNewCategory(e.target.value)}
          placeholder="Nueva categoría"
          className="border rounded px-3 py-1"
        />
        <button
          onClick={handleAddCategory}
          className="btn btn-primary px-4 py-1"
        >
          Añadir
        </button>
      </div>

      <table className="table table-striped">
        <thead>
          <tr>
            <th>Categoría</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {categories.map((cat, index) => (
            <tr key={index}>
              <td>{cat}</td>
              <td>
                <button
                  className="btn btn-warning btn-sm mr-2"
                  onClick={() => handleEditCategory(cat, index)}
                >
                  Editar
                </button>
                <button
                  className="btn btn-danger btn-sm"
                  onClick={() => handleDeleteCategory(index)}
                >
                  Eliminar
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {showModal && (
        <div
          className="modal show d-block"
          tabIndex="-1"
          style={{ display: "block" }}
        >
          <div className="modal-dialog">
            <div className="modal-content">
              <div className="modal-header">
                <h5 className="modal-title">Editar Categoría</h5>
                <button
                  type="button"
                  className="btn-close"
                  onClick={() => setShowModal(false)}
                ></button>
              </div>
              <div className="modal-body">
                <input
                  type="text"
                  value={categoryName}
                  onChange={(e) => setCategoryName(e.target.value)}
                  className="form-control"
                />
              </div>
              <div className="modal-footer">
                <button
                  type="button"
                  className="btn btn-secondary"
                  onClick={() => setShowModal(false)}
                >
                  Cancelar
                </button>
                <button
                  type="button"
                  className="btn btn-primary"
                  onClick={handleSaveCategory}
                >
                  Guardar
                </button>
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}

export default Categories;
