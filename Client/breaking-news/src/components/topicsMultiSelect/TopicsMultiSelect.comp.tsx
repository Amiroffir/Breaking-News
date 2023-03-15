import React, { ChangeEvent, useEffect } from "react";
import { useRecoilState, useRecoilValue } from "recoil";
import { Topic } from "../../interfaces/Topic.interface";
import {
  LocalSelectedTopics,
  SelectedTopics,
} from "../../shareStates/selectedTopics.state";
import { TopicsList } from "../../shareStates/topicsList.state";

const MaxTopics = 3;

export const TopicsMultiSelect = () => {
  const [selectedTopics, setSelectedTopics] =
    useRecoilState<Topic[]>(SelectedTopics);
  const localSelectedTopics = useRecoilValue(LocalSelectedTopics);
  const optionalTopics = useRecoilValue(TopicsList);

  const handleSelection = (e: ChangeEvent, id: number): void => {
    const target = e.target as HTMLInputElement;
    if (target.checked) {
      const topicToAdd: Topic | undefined = optionalTopics.find(
        (topic) => topic.topicID === id
      );
      if (topicToAdd) {
        setSelectedTopics([...selectedTopics, topicToAdd]);
      }
    } else {
      const topicToRemove: Topic | undefined = selectedTopics.find(
        (topic) => topic.topicID === id
      );
      if (topicToRemove) {
        setSelectedTopics(
          selectedTopics.filter((topic) => topic.topicID !== id)
        );
      }
    }
  };
  useEffect(() => {
    setSelectedTopics(localSelectedTopics);
  }, []);

  const handleCheckedUI = (id: number): boolean => {
    const topicToCheck: Topic | undefined = selectedTopics.find(
      (topic) => topic.topicID === id
    );
    if (topicToCheck) {
      return true;
    } else {
      return false;
    }
  };

  return (
    <>
      {optionalTopics &&
        optionalTopics.map((topic: Topic) => (
          <div key={topic.topicID} className="form-check form-switch">
            <input
              className="form-check-input"
              type="checkbox"
              role="switch"
              id={topic.topicID.toLocaleString()}
              onChange={(e) => {
                handleSelection(e, topic.topicID);
              }}
              checked={handleCheckedUI(topic.topicID)}
              disabled={
                selectedTopics.length === MaxTopics &&
                !handleCheckedUI(topic.topicID)
              }
            />
            <label className="form-check-label">{topic.topicName}</label>
          </div>
        ))}
    </>
  );
};
