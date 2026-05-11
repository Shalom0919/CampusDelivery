export type DbPingResponse = {
  message: string
  count: number
}

function toFriendlyErrorMessage(error: unknown): string {
  if (error instanceof Error && error.message) {
    return error.message
  }

  return 'Request failed. Please try again.'
}

export async function getDbPing(): Promise<DbPingResponse> {
  try {
    const response = await fetch('/api/DbTest/ping')

    if (!response.ok) {
      throw new Error(`Request failed with status ${response.status}`)
    }

    const data = (await response.json()) as Partial<DbPingResponse>

    return {
      message: data.message ?? '',
      count: Number(data.count ?? 0),
    }
  } catch (error) {
    throw new Error(toFriendlyErrorMessage(error))
  }
}
