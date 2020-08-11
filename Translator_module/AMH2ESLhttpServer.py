from flask import Flask, jsonify, request
import preprocess_util as putil
import predict
app = Flask(__name__)
PORT=80
DEBUG=True
HOST="0.0.0.0"
ARG_NAME="srcData"
def getTranslation(srcSent):
    return predict(srcSent)

def santitzeTranslation(translation):
    clean_res = putil.clean_data(translation)
    clean_res = re.sub('<PAD>', '' ,clean_res)
    clean_res = re.sub('<EOS>', '' ,clean_res)
    clean_res = re.sub('<UNK>', '' ,clean_res)
    clean_res = re.sub('<GO>', '' ,clean_res)
    return clean_res.strip()

@app.errorhandler(404)
def page_not_found(error):
    return jsonify({
        "status": 404,
        "message": "Bad request"
        }), 404

@app.route('/translate')
def response():
    args = request.args
    if not ARG_NAME in args or args[ARG_NAME] == None or args[ARG_NAME].strip() == "":
        return jsonify({
            "status": 204,
            "message": "No data to translate"
            }), 204
    translation = santitzeTranslation(getTranslation(args[ARG_NAME]))
    return jsonify({
        "status": 200,
        "message": "success",
        ARG_NAME: args[ARG_NAME],
        "translatedData": "this is it"
    })

if __name__ == '__main__':
    app.run(host=HOST, port=PORT, debug=DEBUG)
