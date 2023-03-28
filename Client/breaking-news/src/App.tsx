import { RecoilRoot } from "recoil";
import { BasePage } from "./pages/pagesIndex";
import "./App.scss";

function App() {
  return (
    <div className="app-wrapper">
      <RecoilRoot>
        <BasePage />
      </RecoilRoot>
    </div>
  );
}

export default App;
