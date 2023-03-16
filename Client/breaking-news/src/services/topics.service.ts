import axios from "axios";
import { apiUrl } from "../constants/constants";
import { Topic } from "../interfaces/Topic.interface";

export const getOptionalTopics = async () => {
  const response = await axios.get(`${apiUrl}/settings/get-topics`);
  if (response.status !== 200) {
    throw new Error("Error getting topics");
  }
  return response.data;
};

// export const getSelectedTopicsItems = async (selectedTopics: Topic[]) => {
//   console.log("selectedTopics", selectedTopics);
//   const response = await axios.get(`${apiUrl}/api/news-feed/get`, {
//     params: {
//       selectedTopics: JSON.stringify(selectedTopics),
//     },
//   });
// console.log("response", response);
// if (response.status !== 200) {
//   throw new Error("Error getting topics");
// }
// return response.data;
// };

export const getSelectedTopicsItems = async (selectedTopics: Topic[]) => {
  console.log("selectedTopics", selectedTopics);
  const response = await axios.post(`${apiUrl}/news-feed/get`, selectedTopics);
  console.log("response", response);
};
