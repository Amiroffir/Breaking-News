import React, { useEffect } from "react";
import { useRecoilState } from "recoil";
import { TopicsMultiSelect } from "../../components/compsIndex";
import { Topic } from "../../interfaces/Topic.interface";
import { SelectedTopics } from "../../shareStates/selectedTopics.state";
import { getOptionalTopics } from "../../services/topics.service";
import {
  getFavTopicsFromLocalStorage,
  saveFavTopicsToLocalStorage,
} from "../../services/local-storage.service";
import { TopicsList } from "../../shareStates/topicsList.state";
import { Console } from "console";

export const SettingsPage = () => {
  const [selectedTopics] = useRecoilState<Topic[]>(SelectedTopics);
  const [topicsList, setTopicsList] = useRecoilState<Topic[]>(TopicsList);

  const getTopicsList = async (): Promise<Topic[]> => {
    let topics: Topic[] = await getOptionalTopics();
    if (topics) {
      setTopicsList(topics);
      return topics;
    }
    return [];
  };

  const saveFavTopics = (): void => {
    console.log("selectedTopics: ", selectedTopics);
    saveFavTopicsToLocalStorage("FavoriteTopics", selectedTopics);
  };

  useEffect(() => {
    getTopicsList();
  }, []);

  return (
    <div>
      <TopicsMultiSelect />
      <div>
        <button onClick={() => saveFavTopics()}>Save</button>
      </div>
    </div>
  );
};
