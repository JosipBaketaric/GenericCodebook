export class BaseCodebookFilter {
    codebookName: string;

    // IPaging
    OrderByColumnName: string;
    SortingOrder: string;
    CurrentPageIndex: number;
    NumElementsPerPage: number;
    NumToSkip: number;
}
