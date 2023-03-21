import axios from "axios";
import { apiUrl } from "../constants/constants";
import { Article } from "../interfaces/Article.interface";
import { Topic } from "../interfaces/Topic.interface";

export const updatePopularityInDB = async (
  articleID: number
): Promise<void | null> => {
  try {
    await axios.put(`${apiUrl}/news-feed/update-popularity/${articleID}`);
  } catch (error: any) {
    console.log(error);
    return null;
  }
};

export const getTrendingNews = async (
  selectedTopics: Topic[]
): Promise<Article[] | null> => {
  try {
    const response = await axios.post(`${apiUrl}/trending/get`, selectedTopics);
    console.log("response", response.data);
    return response.data;
  } catch (error: any) {
    console.log(error);
    return null;
  }
};

export const getExploreNews = async (
  selectedTopics: Topic[]
): Promise<Article[] | null> => {
  try {
    const response = await axios.post(`${apiUrl}/explore/get`, selectedTopics);
    console.log("response", response.data);
    return response.data;
  } catch (error: any) {
    console.log(error);
    return null;
  }
};
