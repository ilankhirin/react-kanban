import {
    schema
} from 'normalizr'

const card = new schema.Entity(
    "cardsById", {}, {
        idAttribute: "_id"
    }
)
const list = new schema.Entity(
    "listsById", {
        cards: [card]
    }, {
        idAttribute: "_id"
    }
)
const board = new schema.Entity(
    "boardsById", {
        lists: [list]
    }, {
        idAttribute: "_id"
    }
)

export default board;