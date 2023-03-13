import React, { useEffect } from "react";
import { useRecoilState } from "recoil";
import { TopicsMultiSelect } from "../../components/compsIndex";
import { Topic } from "../../interfaces/Topic.interface";
import { SelectedTopics } from "../../shareStates/selectedTopics.state";
import {
  getFavTopicsFromLocalStorage,
  saveFavTopicsToLocalStorage,
} from "../../services/local-storage.service";

export const SettingsPage = () => {
  const [selectedTopics] = useRecoilState<Topic[]>(SelectedTopics);
  const topicsList: Topic[] = [
    {
      id: 1,
      name: "Sports",
    },
    {
      id: 2,
      name: "topic2",
    },
    {
      id: 3,
      name: "topic3",
    },
    {
      id: 4,
      name: "topic4",
    },
  ];
  const saveFavTopics = (): void => {
    console.log("selectedTopics: ", selectedTopics);
    saveFavTopicsToLocalStorage("FavoriteTopics", selectedTopics);
  };

  return (
    <div>
      <TopicsMultiSelect optionalTopics={topicsList} />
      <div>
        <button onClick={() => saveFavTopics()}>Save</button>
      </div>
    </div>
  );
};
