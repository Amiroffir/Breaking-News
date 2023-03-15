import axios from "axios";
import { apiUrl } from "../constants/constants";

export const getOptionalTopics = async () => {
  const response = await axios.get(`${apiUrl}/settings/get-topics`);
  if (response.status !== 200) {
    throw new Error("Error getting topics");
  }
  return response.data;
};
