import {
  denormalize,
  schema
} from "normalizr";
import dataScheme from './../api/dataScheme'

// Persist the board to the database after almost every action.
const persistMiddleware = (updateBoard, deleteBoard) => store => next => action => {
  next(action);
  if (action.type === "SET_STATE_FROM_SERVER") {
    return;
  }

  const {
    boardsById,
    listsById,
    cardsById,
    currentBoardId: boardId
  } = store.getState();

  if (action.type === "DELETE_BOARD") {
    next({
      type: "SYNCING"
    })
    deleteBoard(boardId).then(x => next({
      type: "SYNCED"
    })).catch(x => next({
      type: "ERROR_SYNCING",
      payload: x
    }));

    // All action-types that are not DELETE_BOARD or PUT_BOARD_ID_IN_REDUX are currently modifying a board in a way that should
    // be persisted to db. If other types of actions are added, this logic will get unwieldy.
  } else if (action.type !== "PUT_BOARD_ID_IN_REDUX") {

    const entities = {
      cardsById,
      listsById,
      boardsById
    };

    const boardData = denormalize(boardId, dataScheme, entities);

    next({
      type: "SYNCING"
    })
    updateBoard(boardData).then(x => next({
      type: "SYNCED"
    })).catch(x => next({
      type: "ERROR_SYNCING",
      payload: x
    }));;
  }
};

export default (updateBoard, deleteBoard) => persistMiddleware(updateBoard, deleteBoard);