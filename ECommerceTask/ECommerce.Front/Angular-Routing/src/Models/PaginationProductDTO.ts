export interface PaginationProductDTO<T> {
    data: T[];
    count: number;
    lastPage: number;
}