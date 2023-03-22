import axios from "axios";
import { apiUrl } from "../constants/constants";
import { Article } from "../interfaces/Article.interface";
import { Topic } from "../interfaces/Topic.interface";

export const getOptionalTopics = async (): Promise<Topic[] | null> => {
  try {
    const response = await axios.get(`${apiUrl}/settings/get-topics`);
    return response.data;
  } catch (error: any) {
    console.log(error);
    return null;
  }
};

export const getSelectedTopicsItems = async (
  selectedTopics: Topic[]
): Promise<Article[] | null> => {
  try {
    const response = await axios.post(
      `${apiUrl}/news-feed/get`,
      selectedTopics
    );
    return response.data;
  } catch (error: any) {
    console.log(error);
    return null;
  }
};
