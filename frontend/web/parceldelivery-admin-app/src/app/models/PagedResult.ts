export interface PagedResult<T> {
  pageNumber: number;
  pageSize: number;
  data: Array<T>;
  totalCount: number;
  totalPages: number;
}
