export interface IPageable<T> {
    currentPage: number 
    pageCount: number
    pageSize: number
    rowCount: number
    results: T[]
}