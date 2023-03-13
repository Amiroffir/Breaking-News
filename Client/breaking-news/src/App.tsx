import { RecoilRoot } from "recoil";
import "./App.scss";
import { BasePage } from "./pages/pagesIndex";

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
