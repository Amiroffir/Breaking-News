export const getFavTopicsFromLocalStorage = <T>(key: string): T => {
  const localStorageValue: string | null = localStorage.getItem(key);
  if (localStorageValue === null) {
    return [] as unknown as T;
  } else {
    return localStorageValue as T;
  }
};

export const saveFavTopicsToLocalStorage = <T>(key: string, value: T): void => {
  const valuesToStore: string = JSON.stringify(value);
  if (value === null) {
    return;
  }
  if (valuesToStore) {
    localStorage.setItem(key, valuesToStore);
  } else {
    return;
  }
};
