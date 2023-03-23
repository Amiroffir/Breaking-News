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
    const selectedTopics = get(LocalSelectedTopics);
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
