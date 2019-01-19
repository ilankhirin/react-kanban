export default (state = {}, action) => {
    switch (action.type) {
        case "SYNCING":
            return {
                status: "SYNCING"
            }
        case "SYNCED":
            return {
                status: "SYNCED"
            }
        case "ERROR_SYNCING":
            return {
                status: "ERROR",
                error: action.payload
            }
        default:
            return state
    }
}