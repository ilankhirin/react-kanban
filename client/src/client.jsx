import React from "react"
import ReactDOM from "react-dom"
import { createStore, applyMiddleware } from "redux"
import { Provider } from "react-redux"
import { composeWithDevTools } from "redux-devtools-extension"
import { BrowserRouter } from "react-router-dom"
import { normalize, schema } from "normalizr"
import rootReducer from "./app/reducers"
import persistMiddleware from "./app/middleware/persistMiddleware"
import App from "./app/components/App"
import { updateBoard, deleteBoard, getAllBoards } from "./app/api/boardApi"
import dataScheme from "./app/api/dataScheme"

const store = createStore(
  rootReducer,
  {},
  composeWithDevTools(
    applyMiddleware(persistMiddleware(updateBoard, deleteBoard))
  )
)

getAllBoards().then(data => {
  const normalized = normalize(data, new schema.Array(dataScheme))
  store.dispatch({
    type: "SET_STATE_FROM_SERVER",
    payload: normalized.entities
  })
})

ReactDOM.hydrate(
  <Provider store={store}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Provider>,
  document.getElementById("app")
)
