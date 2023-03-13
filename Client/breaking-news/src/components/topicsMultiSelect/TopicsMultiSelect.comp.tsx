import React, { ChangeEvent, useEffect } from "react";
import { useRecoilState, useRecoilValue } from "recoil";
import { Topic } from "../../interfaces/Topic.interface";
import {
  LocalSelectedTopics,
  SelectedTopics,
} from "../../shareStates/selectedTopics.state";

interface TopicsMultiSelectProps {
  optionalTopics: Topic[];
}
const MaxTopics = 3;

export const TopicsMultiSelect = ({
  optionalTopics,
}: TopicsMultiSelectProps) => {
  const [selectedTopics, setSelectedTopics] =
    useRecoilState<Topic[]>(SelectedTopics);
  const localSelectedTopics = useRecoilValue(LocalSelectedTopics);

  const handleSelection = (e: ChangeEvent, id: number): void => {
    const target = e.target as HTMLInputElement;
    if (target.checked) {
      const topicToAdd: Topic | undefined = optionalTopics.find(
        (topic) => topic.id === id
      );
      if (topicToAdd) {
        setSelectedTopics([...selectedTopics, topicToAdd]);
      }
    } else {
      const topicToRemove: Topic | undefined = selectedTopics.find(
        (topic) => topic.id === id
      );
      if (topicToRemove) {
        setSelectedTopics(selectedTopics.filter((topic) => topic.id !== id));
      }
    }
  };
  useEffect(() => {
    setSelectedTopics(localSelectedTopics);
  }, []);

  const handleCheckedUI = (id: number): boolean => {
    const topicToCheck: Topic | undefined = selectedTopics.find(
      (topic) => topic.id === id
    );
    if (topicToCheck) {
      return true;
    } else {
      return false;
    }
  };

  return (
    <>
      {localSelectedTopics &&
        optionalTopics.map((topic: Topic) => (
          <div key={topic.id} className="form-check form-switch">
            <input
              className="form-check-input"
              type="checkbox"
              role="switch"
              id={topic.id.toLocaleString()}
              onChange={(e) => {
                handleSelection(e, topic.id);
              }}
              checked={handleCheckedUI(topic.id)}
              disabled={
                selectedTopics.length === MaxTopics &&
                !handleCheckedUI(topic.id)
              }
            />
            <label className="form-check-label">{topic.name}</label>
          </div>
        ))}
    </>
  );
};
