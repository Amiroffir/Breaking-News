import { RecoilState, atom } from "recoil";
import { Topic } from "../interfaces/Topic.interface";
import { getFavTopicsFromLocalStorage } from "../services/local-storage.service";

export const TopicsList: RecoilState<Topic[]> = atom<Topic[]>({
  key: "topicsList",
  default: [],
});
