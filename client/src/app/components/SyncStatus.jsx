import React from "react"
import { connect } from "react-redux"

const BoardSyncStatus = props => {
  const { syncStatus } = props
  const { status, error } = syncStatus

  switch (status) {
    case "SYNCED":
      return <div>Synced.</div>
    case "SYNCING":
      return <div>Syncing...</div>
    case "ERROR":
      console.error("Error syncing data to server", error)
      return <div>Error Syncing</div>
    default:
      return <div>No Actions Were Made Yet</div>
  }
}

const mapStateToProps = state => {
  return {
    syncStatus: state.syncStatus
  }
}

export default connect(mapStateToProps)(BoardSyncStatus)
