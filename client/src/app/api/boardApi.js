import * as config from './../config/config'

export const updateBoard = (boardData) => {
  return fetch(`${config.backendUrl}/board`, {
    method: "PUT",
    body: JSON.stringify(boardData),
    headers: {
      "Content-Type": "application/json"
    },
    credentials: "include"
  });
}

export const deleteBoard = (boardId) => {
  return fetch(`${config.backendUrl}/board/${boardId}`, {
    method: "DELETE",
    credentials: "include"
  });
}

export const getAllBoards = () => {
  return fetch(`${config.backendUrl}/board`).then(x => x.json());
}