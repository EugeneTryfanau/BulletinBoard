export class PageResult<T> {
  count: number | undefined;
  pageIndex: number | undefined;
  pageSize: number | undefined;
  items: T[] | undefined;
}
