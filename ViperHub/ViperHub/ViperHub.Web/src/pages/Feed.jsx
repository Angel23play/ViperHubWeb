import React, { useState } from "react";
import PostList from "../components/PostList";
import PostInput from "../components/PostInput";

function Feed() {
  const [showPostInput, setShowPostInput] = useState(false);
  const [handle, setHandle] = useState(0); // 0 = Crear, 1 = Editar
  const [postId, setPostId] = useState(null);

  return (
    <div className="container mt-4">
      <h2 className="text-2xl font-bold mb-4">Últimas Noticias</h2>
      <button
        className={`btn ${showPostInput ? "btn-danger" : "btn-success"} mb-3`}
        onClick={() => {
          setShowPostInput(!showPostInput);
          setHandle(0); // Reset para nueva publicación
          setPostId(null);
        }}
      >
        {showPostInput ? "Cancelar" : "Añadir Nueva Publicación"}
      </button>

      {showPostInput && <PostInput handle={handle} postId={postId} />}
      <PostList setHandle={setHandle} setPostId={setPostId} setShowPostInput={setShowPostInput} />
    </div>
  );
}

export default Feed;
