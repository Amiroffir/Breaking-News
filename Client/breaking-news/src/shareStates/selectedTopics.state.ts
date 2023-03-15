import { atom, RecoilState, selector } from "recoil";
import { Topic } from "../interfaces/Topic.interface";
import { getFavTopicsFromLocalStorage } from "../services/local-storage.service";

export const SelectedTopics: RecoilState<Topic[]> = atom<Topic[]>({
  key: "selectedTopics",
  default: [],
});
export const SelectedTopicsNames = selector({
  key: "selectedTopicsNames",
  get: ({ get }) => {
    const selectedTopics = get(SelectedTopics);
    return selectedTopics.map((topic: Topic) => topic.topicName);
  },
});

export const LocalSelectedTopics = selector({
  key: "localSelectedTopics",
  get: () => {
    let topics: Topic[] = getFavTopicsFromLocalStorage("FavoriteTopics");
    if (topics) {
      return JSON.parse(topics as unknown as string);
    }
    return [];
  },
});

// export const AddSelectedTopics = selector({
//   key: "addSelectedTopics",
//   get: ({ get }) => {
//     const selectedTopics = get(SelectedTopics);
//     return selectedTopics;
//   },
//   set: ({ set }, newValue) => {
//     set(SelectedTopics, newValue);
//   },
// });

// export const CounterState = atom({
//   key: "counterState",
//   default: 0,
// });
// export const VatCalcState = selector({
//   key: "vatCalcState",
//   get: ({ get }) => {
//     const vat = get(CounterState) * 1.17;
//     return vat;
//   },
// });
// export const changeOriginalState = selector({
//   key: "OriginalState",
//   get: ({ get }) => {
//     const vat = get(CounterState);
//     return vat;
//   },
//   set: ({ set }, newValue) => {
//     set(CounterState, (newValue * 8) / 3);
//   },
// });
