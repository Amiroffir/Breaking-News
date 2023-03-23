import { RecoilState, atom } from "recoil";
import { Topic } from "../interfaces/Topic.interface";

export const TopicsList: RecoilState<Topic[]> = atom<Topic[]>({
  key: "topicsList",
  default: [],
});
