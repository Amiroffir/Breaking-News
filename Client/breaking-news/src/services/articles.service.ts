import axios from "axios";
import { apiUrl } from "../constants/constants";
import { Article } from "../interfaces/Article.interface";
import { Topic } from "../interfaces/Topic.interface";

export const updatePopularityInDB = async (
  articleID: number
): Promise<void> => {
  await axios.put(`${apiUrl}/news-feed/update-popularity/${articleID}`);
};

export const getTrendingNews = async (
  selectedTopics: Topic[]
): Promise<Article[]> => {
  const response = await axios.post(`${apiUrl}/trending/get`, selectedTopics);
  console.log("response", response.data);
  return response.data;
};

export const getExploreNews = async (
  selectedTopics: Topic[]
): Promise<Article[]> => {
  const response = await axios.post(`${apiUrl}/explore/get`, selectedTopics);
  console.log("response", response.data);
  return response.data;
};
