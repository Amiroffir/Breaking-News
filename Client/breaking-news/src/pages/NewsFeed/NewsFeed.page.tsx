import React, { useEffect } from "react";
import axios from "axios";
import { useRecoilValue } from "recoil";
import { ItemsDisplay } from "../../components/compsIndex";
import { Article } from "../../interfaces/Article.interface";
import {
  LocalSelectedTopics,
  SelectedTopics,
} from "../../shareStates/selectedTopics.state";
import { apiUrl } from "../../constants/constants";
import { getSelectedTopicsItems } from "../../services/topics.service";
import { Topic } from "../../interfaces/Topic.interface";

const ArticlesJustForTesting: Article[] = [
  {
    articleID: 1,
    articleTitle: "Article 1",
    articleDescription: "Article 1 description",
    articleLink: "https://www.google.com",
    articleImage: "https://www.google.com",
  },
  {
    articleID: 2,
    articleTitle: "Article 2",
    articleDescription: "Article 2 description",
    articleLink: "https://www.google.com",
    articleImage: "https://www.google.com",
  },
  {
    articleID: 3,
    articleTitle: "Article 3",
    articleDescription: "Article 3 description",
    articleLink: "https://www.google.com",
    articleImage: "https://www.google.com",
  },
];

export const NewsFeedPage = () => {
  const selectedTopics: Topic[] = useRecoilValue(LocalSelectedTopics);

  const getSelectedTopics = async () => {
    console.log("selectedTopics", selectedTopics);
    const res = await getSelectedTopicsItems(selectedTopics);
    console.log("res", res);
  };

  useEffect(() => {
    getSelectedTopics();
  }, []);

  return (
    <div>
      NewsFeed.page
      <ItemsDisplay articlesList={ArticlesJustForTesting} />
    </div>
  );
};
