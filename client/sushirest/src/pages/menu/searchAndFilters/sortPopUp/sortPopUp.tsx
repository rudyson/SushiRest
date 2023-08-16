import style from "./sortPopUp.module.scss"
import {useEffect, useRef, useState} from "react";
export const SortPopUp = ({ sortId, onChangeSort }) => {
    const [open, setOpen] = useState(false)
    const sort = ['Price','Popularity','Test']
    const sortName = sort[sortId]
    const sortRef = useRef()

    const onClickSortItem = (id) => {
        onChangeSort(id)
        setOpen(false)
    }

    useEffect(() => {
        const handleClickOutside = (event) => {
            if (!event.composedPath().includes(sortRef.current)) {
                setOpen(false)
            }
        };

        document.body.addEventListener('click', handleClickOutside)

        // unmount component
        return () => {
            document.body.removeEventListener('click', handleClickOutside)
        }
    }, [])

    return (
        <div ref = {sortRef} className={style.wrapper}>
            <section onClick={() => setOpen(!open)} className={open === true ? style.activeWrapperSec : style.wrapperSec}>
                <p>{sortName}</p>
                <svg width="18" height="13" viewBox="0 0 18 13" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M1 1L9 11L17 1" stroke="#2E2E2E" strokeWidth="2"/>
                </svg>
            </section>
            {open && (
                <ul className={style.options}>
                    {
                        sort.map((el, i) => (
                            <li onClick={() => onClickSortItem(i)} key={i}>{el}</li>
                        ))
                    }
                </ul>
            )}
        </div>
    )
}
