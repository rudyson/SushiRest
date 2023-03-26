import style from "./TextPartHeader.module.css"
import logo from "../../../../../../pics/logo.png"
import HeaderMainButton from "./HeaderMainButton/HeaderMainButton";
const TextPartHeader = () => {
    return (
        <div className={style.wrapper}>
            <img className={style.Logo} src={logo}></img>
            <p className={style.MainText}>Good <span>Food &emsp;Good</span> <br></br>Moments</p>
            <p className={style.SmallText}>Everyone should do what they do best in life.
                Here, for example, we make sushi. The best sushi, unforgettabletaste in every piece.</p>
            <HeaderMainButton/>
        </div>
    );
}
export default TextPartHeader;