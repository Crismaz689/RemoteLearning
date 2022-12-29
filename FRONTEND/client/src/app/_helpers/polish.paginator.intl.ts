import { MatPaginatorIntl } from "@angular/material/paginator";

const polishRangeLabel = (page: number, pageSize: number, length: number) => {
    if (length == 0 || pageSize == 0) {
      return `1 z ${length + 1} stron`;
    }
  
    length = Math.max(length, 0);
  
    const startIndex = page * pageSize;

    const endIndex =
      startIndex < length
        ? Math.min(startIndex + pageSize, length)
        : startIndex + pageSize;
  
    return `${startIndex + 1} - ${endIndex} z ${length}`;
  };

export function getPolishPaginatorIntl() {
    const paginatorIntl = new MatPaginatorIntl();
  
    paginatorIntl.itemsPerPageLabel = "Elementów na stronie";
    paginatorIntl.getRangeLabel = polishRangeLabel;
  
    return paginatorIntl;
  }