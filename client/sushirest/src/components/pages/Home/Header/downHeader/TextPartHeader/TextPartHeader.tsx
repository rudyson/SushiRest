import style from "./TextPartHeader.module.css"
import logo from "../../../../../../pics/headerPic/logo.png"
import HeaderMainButton from "./HeaderMainButton/HeaderMainButton";
const TextPartHeader = () => {
    return (
        <div className={style.wrapper}>
            <img className={style.logo} src={logo}></img>
            <p className={style.mainText}>Good <span>Food &emsp;Good</span> <br></br>Moments</p>
            <p className={style.smallText}>Everyone should do what they do best in life.
                Here, for example, we make sushi. The best sushi, unforgettabletaste in every piece.</p>
            <HeaderMainButton/>
        </div>
    );
}
export default TextPartHeader;